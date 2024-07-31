window.initializeCropper = (imageSelector) => {
    const image = document.querySelector(imageSelector);
    if (window.cropper) {
        window.cropper.destroy();
    }
    window.cropper = new Cropper(image, {
        aspectRatio: 1,  // Square crop
        viewMode:0,
        autoCropArea: 1,
    });
};

window.cropImage = () => {
    return new Promise((resolve, reject) => {
        if (window.cropper) {
            try {
                const canvas = window.cropper.getCroppedCanvas({
                    width: 200,  // Fixed width
                    height:200, // Fixed height
                });
                const croppedImage = canvas.toDataURL('image/jpeg');  // Specify JPG format
                resolve(croppedImage);
            } catch (error) {
                reject('Error cropping image: ' + error.message);
            }
        } else {
            reject('Cropper not initialized.');
        }
    });
};
