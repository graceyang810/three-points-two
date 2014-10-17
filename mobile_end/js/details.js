// JavaScript Document
$(document).ready(function () {
 // jQuery("#nanoGallery").nanoGallery();
 jQuery("#nanoGallery").nanoGallery({thumbnailWidth:70,thumbnailHeight:70,
        items: [
            {
                src: '../Resources/img/img1.jpg',        // 图片网址
                srct: '../Resources/img/img1.jpg'       // 缩略图链接
            },
            {
                src: '../Resources/img/img2.jpg',
                srct: '../Resources/img/img2.jpg'
            },
			{
                src: '../Resources/img/img2.jpg',
                srct: '../Resources/img/img2.jpg'
            },
			{
                src: '../Resources/img/img2.jpg',
                srct: '../Resources/img/img2.jpg'
            }
        ]
    });
});