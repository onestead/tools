function imagickNgFromPdfToPng($inputPdfFullName, $outputPngRootPath) {
    $image = new Imagick();
    $image->setResourceLimit(imagick::RESOURCETYPE_FILE, 32);
    $image->setResolution(144, 144);
    $image->readImage($inputPdfFullName);
    $image->setImageColorspace(imagick::COLORSPACE_SRGB);
    $image->setImageFormat("png");
    $image->setImageCompression(imagick::COMPRESSION_UNDEFINED);
    $image->setImageCompressionQuality(0);
    $image->setBackgroundColor(new ImagickPixel('white'));
    $image->setImageAlphaChannel(imagick::ALPHACHANNEL_DEACTIVATE);
    $count = $image->getImageScene();
    for ($i = 0; $i <= $count; $i++) {
        $image->setIteratorIndex($i);
        $image->stripImage();
        $image->adaptiveResizeImage(1280, 800, true);
        $image->writeImage(sprintf("%s%s%d.png", $outputPngRootPath, DS, $i));
    }
    $image->clear();
    $image->destroy();
    $image = null;
}

function imagickOkFromPdfToPng($inputPdfFullName, $outputPngRootPath) {
    $input = new Imagick();
    $input->setResourceLimit(imagick::RESOURCETYPE_FILE, 32);
    $input->setResolution(144, 144);
    $input->readImage($inputPdfFullName);
    $input->setImageColorspace(imagick::COLORSPACE_SRGB);
    $count = $input->getImageScene();
    for ($i = 0; $i <= $count; $i++) {
        $input->setIteratorIndex($i);
        $input->stripImage();
        $input->adaptiveResizeImage(1280, 800, true);
        $size = $input->getImageGeometry();
        $output = new Imagick();
        $output->setResourceLimit(imagick::RESOURCETYPE_FILE, 32);
        $output->setResolution(144, 144);
        $output->newImage($size['width'], $size['height'], new ImagickPixel('white'));
        $output->setImageColorspace(imagick::COLORSPACE_SRGB);
        $output->setImageFormat("png");
        $output->setImageCompression(imagick::COMPRESSION_UNDEFINED);
        $output->setImageCompressionQuality(0);
        $output->compositeImage($input, imagick::COMPOSITE_DEFAULT, 0, 0, imagick::CHANNEL_ALL);
        $output->writeImage(sprintf("%s%s%d.png", $outputPngRootPath, DS, $i));
        $output->clear();
        $output->destroy();
        $output = null;
    }
    $input->clear();
    $input->destroy();
    $input = null;
}
