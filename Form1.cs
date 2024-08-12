using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;

using Microsoft.WindowsAPICodePack.Dialogs;

namespace BarcodeReader
{
    public partial class Form1 : Form
    {
        #region Constructor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion


        #region Property

        #endregion

        #region Event Handlers
        private void buttonSetPath_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dlg = new CommonOpenFileDialog();
            dlg.IsFolderPicker = true;

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                this.textBoxFolder.Text = dlg.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> imageFiles = new List<string>();
            string directoryPath = this.textBoxFolder.Text;

            if (string.IsNullOrEmpty(directoryPath)) return;
            imageFiles.AddRange(Directory.GetFiles(this.textBoxFolder.Text, "*.bmp"));
            imageFiles.AddRange(Directory.GetFiles(directoryPath, "*.jpg"));
            labelProcess.Text = $"0 / {imageFiles.Count}";
            labelProcess.Refresh();
            ZXing.BarcodeReader reader = new ZXing.BarcodeReader();
            ThresholdType thresholdType = ThresholdType.Binary;

            int fileCount = 1;

            if (255 - int.Parse(this.textBoxThreshold.Text) <= 0 || int.Parse(this.textBoxAddThreshold.Text) == 0)
            {
                return;
            }

            int addCount = (255 - int.Parse(this.textBoxThreshold.Text)) / int.Parse(this.textBoxAddThreshold.Text);
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string resultString = string.Empty;

            foreach (string file in imageFiles)
            {
                ZXing.Result result = null;

                using (Bitmap bitmap = new Bitmap(file))
                using (Mat emguImage = bitmap.ToMat())
                using (Mat grayImage = new Mat())
                {
                    CvInvoke.CvtColor(emguImage, grayImage, ColorConversion.Bgr2Gray);

                    reader.AutoRotate = true;
                    reader.Options = new ZXing.Common.DecodingOptions
                    {
                        TryHarder = true,
                    };

                    int addThreshold = 0;

                    for (int i = 0; i < addCount; i++)
                    {
                        using (Mat binary = new Mat())
                        {
                            double thresholdValue = double.Parse(this.textBoxThreshold.Text) + addThreshold;
                            if (thresholdValue > 255) thresholdValue = 255;

                            CvInvoke.Threshold(grayImage, binary, thresholdValue, 255, ThresholdType.BinaryInv);

                            using (Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1)))
                            using (Mat dilatedImage = new Mat())
                            {
                                CvInvoke.Dilate(binary, dilatedImage, kernel, new Point(-1, -1), 1, BorderType.Default, new Emgu.CV.Structure.MCvScalar(0));

                                // 필요할 때만 ToBitmap() 호출
                                using (Bitmap decodeBitmap = dilatedImage.ToBitmap())
                                {
                                    result = reader.Decode(decodeBitmap);
                                }

                                if (result != null)
                                {
                                    thresholdType = ThresholdType.BinaryInv;
                                    break;
                                }
                            }
                        }
                        addThreshold += int.Parse(this.textBoxAddThreshold.Text);
                    }

                    if (this.checkBoxInversion.Checked == true)
                    {
                        if (result == null)
                        {
                            addThreshold = 0;

                            for (int i = 0; i < addCount; i++)
                            {
                                using (Mat binary = new Mat())
                                {
                                    double thresholdValue = double.Parse(this.textBoxThreshold.Text) + addThreshold;
                                    if (thresholdValue > 255) thresholdValue = 255;

                                    CvInvoke.Threshold(grayImage, binary, thresholdValue, 255, ThresholdType.Binary);

                                    using (Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1)))
                                    using (Mat dilatedImage = new Mat())
                                    {
                                        CvInvoke.Dilate(binary, dilatedImage, kernel, new Point(-1, -1), 1, BorderType.Default, new Emgu.CV.Structure.MCvScalar(0));

                                        using (Bitmap decodeBitmap = dilatedImage.ToBitmap())
                                        {
                                            result = reader.Decode(decodeBitmap);
                                        }

                                        if (result != null)
                                        {
                                            thresholdType = ThresholdType.Binary;
                                            break;
                                        }
                                    }
                                    addThreshold += int.Parse(this.textBoxAddThreshold.Text);
                                }
                            }
                        }
                    }

                    if (result != null)
                    {
                        resultString = $" [File]" + Path.GetFileName(file) + $"_[{thresholdType}] : " + result.ToString() + Environment.NewLine;
                    }
                    else
                    {
                        resultString = timestamp + " [File]" + Path.GetFileName(file) + " : Read Fail" + Environment.NewLine;
                    }

                    this.textBoxLog.AppendText(resultString);

                    using (StreamWriter logWriter = new StreamWriter("Result.log", true))
                    {
                        logWriter.WriteLine(resultString);
                    }
                }

                labelProcess.Text = $"{fileCount} / {imageFiles.Count}";
                labelProcess.Refresh();
                fileCount++;
            }
        }
        #endregion

        #region Form Members
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
        #endregion


    }
}
