namespace Image_Gallery_Demo
{
    class ImageItem
    {
        public string Id { get; set; }      //to set and get the id of image
        public string Name { get; set; }    //to set and get the name of image
        public byte[]Base64 { get; set; }   //to set and get the base64 URI of image
        public string Format { get; set; }  //to set and get the format of the image=
    }
}
