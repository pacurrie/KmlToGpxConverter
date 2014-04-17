using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KmlToGpxConverter
{
    public partial class Form1 : Form
    {
        private BackgroundWorker worker;

        public Form1()
        {
            InitializeComponent();
            checkBoxStripElevationData_CheckedChanged(null, null);

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += ProcessFiles;
            worker.RunWorkerCompleted += ProcessingCompleted;

            toolStripStatusLabel1.Text = "Ready";
        }

        private void groupBox2_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (!worker.IsBusy && data is string[])
            {
                worker.RunWorkerAsync(new ProcessingArguments { 
                    files = new List<string>(data as string[]), 
                    elevationAdjustment = checkBoxStripElevationData.Checked ? ((decimal?) null) : numericUpDownElevationAdjustment.Value });
            }

        }

        private void groupBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (!worker.IsBusy && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void checkBoxStripElevationData_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownElevationAdjustment.Enabled = !checkBoxStripElevationData.Checked;
        }

        private void ProcessingCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                var msg = MessageBox.Show("Error during processing file(s): " + e.Error.Message);
            }
            this.Invoke(()=> toolStripStatusLabel1.Text = "Ready");
        }

        private void ProcessFiles(object sender, DoWorkEventArgs e)
        {
            var bw = sender as BackgroundWorker;
            var args = e.Argument as ProcessingArguments;
            if (args == null)
            {
                throw new Exception("No/invalid arguments");
            }
            this.Invoke(() => toolStripStatusLabel1.Text = "Processing");

            var exceptions = new List<Exception>();
            foreach (var file in args.files)
            {
                try
                {
                    List<GpsTimePoint> gpsPoints = new List<GpsTimePoint>();

                    // Read raw data
                    if (Path.GetExtension(file) == ".kmz")
                    {
                        var archive = ZipFile.OpenRead(file);
                        foreach (var entry in archive.Entries)
                        {
                            var dstFile = System.IO.Path.GetTempFileName();
                            try
                            {
                                File.Delete(dstFile);
                                entry.ExtractToFile(dstFile);
                                gpsPoints.AddRange(KmlReader.ReadFile(dstFile));
                            }
                            finally
                            {
                                File.Delete(dstFile);
                            }
                        }
                    }
                    else
                    {
                        gpsPoints.AddRange(KmlReader.ReadFile(file));
                    }

                    // Filter data
                    if (args.elevationAdjustment.HasValue)
                    {
                        if (args.elevationAdjustment != Decimal.Zero)
                        {
                            gpsPoints = gpsPoints.Select(x => GpsTimePointMutator.AdjustElevation(x, args.elevationAdjustment.Value)).ToList();
                        }
                    }
                    else
                    {
                        gpsPoints = gpsPoints.Select(x => GpsTimePointMutator.StripElevation(x)).ToList();
                    }

                    // Output data
                    var outFileName = GetAvailableFilename(file, GpxWriter.FileExtension);
                    GpxWriter.WriteFile(outFileName, gpsPoints);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        private string GetAvailableFilename(string origFileName, string newExtension)
        {
            var baseFileName = Path.GetFullPath(origFileName);

            var origExtensionTrimmed = Path.GetExtension(baseFileName).TrimStart(new[]{'.'});
            baseFileName = baseFileName.Substring(0, baseFileName.Length - origExtensionTrimmed.Length - 1);

            string newFile;
            var count = 0;
            do
            {
                newFile = baseFileName + (count == 0 ? string.Empty : " (" + count + ")") + "." + newExtension.TrimStart(new[] { '.' });
                count++;
            }
            while (File.Exists(newFile));

            return newFile;
        }
    }

    internal class ProcessingArguments
    {
        public List<string> files;
        public decimal? elevationAdjustment;
    }
}

public static class blah
{
    public static void Invoke(this Control control, Action a)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(a);
        }
        else
        {
            a();
        }
    }
}