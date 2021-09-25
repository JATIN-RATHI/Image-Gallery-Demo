using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using C1.Win.C1Tile;
using C1.C1Pdf;

namespace Image_Gallery_Demo
{
    public partial class ImageGallery : Form
    {
        DataFetcher datafetch = new DataFetcher();  //created an instance of datafetecher
        List<ImageItem> imageList;                  //created an instance of ImageItem class
        int checkedItems = 0;                       //initilized checkItems with 0 
        public ImageGallery() //Window Appln. depends upon it
        {
            //initializing all the components we are using in application
            //such as textbox, panel, etc
            InitializeComponent();   
        }
        private async void OnSearchClick(object sender, EventArgs e) 
        {
            statusStrip1.Visible = true;    //status set to true when searching for images
            imageList = await datafetch.GetImageData(_searchBox.Text); //fetching data from server
            AddTiles(imageList);        //calling method to display
            statusStrip1.Visible = false;   //status set to false when result shown
        }
        //method will loop through all the images and add it to the tile control
        private void AddTiles(List<ImageItem> imageList)
        {
            _imageTileControl.Groups[0].Tiles.Clear();
            foreach(var imageitem in imageList)
            {
                Tile tile = new Tile();
                tile.HorizontalSize = 2;
                tile.VerticalSize = 2;

                _imageTileControl.Groups[0].Tiles.Add(tile);
                //It converts the base64 encoding to 
                //the corresponding image using MemoryStream class
                Image img = Image.FromStream(new MemoryStream(imageitem.Base64));

                Template tl = new Template();
                ImageElement ie = new ImageElement();
                ie.ImageLayout = ForeImageLayout.Stretch;
                tl.Elements.Add(ie);
                tile.Template = tl;
                tile.Image = img;
            }
        }
        //to increase counter if images is selected
        private void OnTileChecked(object sender, TileEventArgs e)
        {
            checkedItems++;
            _exportImage.Visible = true;  //show export button when images selected > 1
            savePicture.Visible = true;
        }
        //to decrease counter if images is unselected
        private void OnTileUnchecked(object sender, TileEventArgs e)
        {
            checkedItems--;
            savePicture.Visible = checkedItems > 0;
            _exportImage.Visible = checkedItems > 0; //hide export button when 0 = false
        }

        //on export to pdf button clicked this method triggered
        //it iterates through all the tiles, gets it's image and convert this into pdf
        private void OnExportClick(object sender, EventArgs e)
        {
            List<Image> images = new List<Image>();            
            foreach (Tile tile in _imageTileControl.Groups[0].Tiles)
            {
                if (tile.Checked)
                {
                    images.Add(tile.Image);  //adding images in list which are selected
                }
            }
            ConvertToPdf(images);   //calling a method
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "pdf";
            saveFile.Filter = "*.pdf|PDF files";
            try
            {
                if(saveFile.ShowDialog() == DialogResult.OK)
                {
                    c1pdfDocument.Save(saveFile.FileName);
                    MessageBox.Show("Files Saved Successfully!");
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Error Occured!" );
            }
        }

        //This method creates a page for each image and draws the
        //image using DrawImage method
        private void ConvertToPdf(List<Image> images)
        {
            RectangleF rect = c1pdfDocument.PageRectangle;
            bool firstPage = true;
            try
            {
                foreach (var selectedimg in images)
                {
                    if (!firstPage)
                    {
                        c1pdfDocument.NewPage();  //new page for every image in list
                    }
                    firstPage = false;

                    rect.Inflate(-72, -72);  //size of image 
                    c1pdfDocument.DrawImage(selectedimg, rect); //drawing or copying image
                }
            }
            catch
            {
                MessageBox.Show("Error Occured!");
            }
        }
        //to add a grey border to the search box
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = _searchBox.Bounds;
            r.Inflate(3, 3);
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawRectangle(p, r);
        }
        //used for drawing a grey border for export to pdf button
        private void OnExportImagePaint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(_exportImage.Location.X,_exportImage.Location.Y,
                _exportImage.Width, _exportImage.Height);
            r.X -= 29;
            r.Y -= 3;
            r.Width--;
            r.Height--;
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawRectangle(p, r);
            e.Graphics.DrawLine(p, new Point(0, 43), new Point(this.Width, 43));

        }
        //used to draw a separator
        private void OnTilePaint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawLine(p, 0, 43, 800, 43);
        }

        private void onClickSavePicture(object sender, EventArgs e)
        {
            List<Image> images = new List<Image>();
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "jpg";  //default format of image
            saveFile.Filter = "*.jpg|JPeg Image|*.png|Png Image|*.bmp|Bitmap Image|*.gif|Gif Image|*.raw|Raw Image";  //formats of image user can choose while saving
            try
            {
                foreach (Tile tile in _imageTileControl.Groups[0].Tiles)
                {
                    if (tile.Checked)
                    {
                        images.Add(tile.Image);  //adding images in list which are selected
                    }
                }
                for (int img = 0; img < images.Count; img++)
                {
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        images[img].Save(saveFile.FileName);
                        MessageBox.Show("Image Saved Successfully!");  //show the message after saving
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error Occured!");
            }
            
        }
    }
}
