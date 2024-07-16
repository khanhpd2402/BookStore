// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Hàm để xoay ảnh tự động
window.onload = function () {
    autoRotateImage(); // Gọi hàm xoay ảnh tự động khi trang đã tải
};

function autoRotateImage() {
    var image = document.getElementById('loginImage');
    var rotation = 0;

    setInterval(function () {
        rotation += 1; // Độ xoay mỗi lần lặp (tùy ý)
        image.style.transform = 'rotate(' + rotation + 'deg)';
    }, 50); // Thời gian giữa các lần xoay (tùy ý, 50ms trong ví dụ này)
}