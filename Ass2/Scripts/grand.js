const images = ["Content/Images/Slideshow/afd.jpg", "Content/Images/Slideshow/lyzl.jpg", "Content/Images/Slideshow/fs.jpg", "Content/Images/Slideshow/hdtg.jpg"]; // 替换为你的图像文件名
let currentIndex = 0;
var img = document.getElementsByClassName("myImage")[0];
function prevImage() {
    currentIndex = (currentIndex - 1 + images.length) % images.length;
    updateImage();
    updateIndicators();
}

function nextImage() {
    currentIndex = (currentIndex + 1) % images.length;
    updateImage();
    updateIndicators();
}

function goToImage(index) {
    currentIndex = index;
    updateImage();
    updateIndicators();

}

function updateImage() {
    img.src = images[currentIndex]
}

function updateIndicators() {

    const indicators = document.querySelectorAll(".indicator");
    indicators.forEach((indicator, index) => {
        if (index === currentIndex) {
            indicator.classList.add("active");
        } else {
            indicator.classList.remove("active");
        }
    });
}
const first = [
    { Name: "Assault", Score : 6.9, URL : "~/Content/Images/latest/Assault.jpg", },
    { Name : "Harold Fry", Score : 7.4, URL : "~/Content/Images/latest/Harold Fry.jpg", },
    { Name: "Inference", Score : 6.8, URL : "~/Content/Images/latest/Inference.jpg", },
    { Name: "Sleep", Score : 5.8, URL : "~/Content/Images/latest/Sleep.jpg", },
    { Name: "The Burial", Score :7.0, URL : "~/Content/Images/latest/The Burial.jpg", },

    { Name: "Beautiful diaster", Score : 5.5, URL : "~/Content/Images/latest/Beautiful diaster.jpg", },
    { Name: "Oh My God", Score: 7.3, URL: "~/Content/Images/latest/Oh My God.jpg" },
    { Name: "Shyloch's children", Score: 6.8, URL : "~/Content/Images/latest/Shyloch's children.jpg", },
    { Name: "She is so sweet", Score: 5.4, URL: "~/Content/Images/latest/She is so sweet.jpg", },
    { Name: "Roman Prince", Score: 7.2, URL: "~/Content/Images/latest/Roman Prince.jpg", }, 
]; 
const second = [
    { Name: "Anatomy of a fall", Score: 8.4, URL: "~/Content/Images/hot/AnatomyOfAFall.jpg" },
    { Name: "Saw X", Score: 7.5, URL: "~/Content/Images/hot/SawX.jpg", },
    { Name: "Long Live Love", Score: 7.6, URL: "~/Content/Images/hot/LongLiveLove.jpg", },
    { Name: "The Killer", Score: 6.7, URL: "~/Content/Images/hot/TheKiller.jpg", },
    { Name: "Old Dads", Score: 6.4, URL: "~/Content/Images/hot/OldDads.jpg", },

    { Name: "Passed Through the storm", Score: 6.6, URL: "~/Content/Images/hot/Passed Through the storm.jpg", },
    { Name: "Sound Of Freedom", Score: 7.8, URL: "~/Content/Images/hot/Sound Of Freedom.jpg", },
    { Name: "Revenge", Score: 6.9, URL: "~/Content/Images/hot/Revenge.jpg", },
    { Name: "Nowhere", Score: 7.0, URL: "~/Content/Images/hot/Nowhere.jpg", },
    { Name: "Learn From Dad", Score: 6.1, URL: "~/Content/Images/hot/Learn From Dad.jpg", },

]
const ul = document.querySelector('.clearfix');
const itemsPerPage = 10; // 每页显示的项数
let currentPage = 1;

function showItems(page) {
    const startIndex = (page - 1) * itemsPerPage;
    const endIndex = startIndex + itemsPerPage;

    const lis = ul.querySelectorAll('li');
    lis.forEach((li, index) => {
        if (index >= startIndex && index < endIndex) {
            li.style.display = 'block';
        } else {
            li.style.display = 'none';
        }
    });
}

showItems(currentPage);

const prevPageButton = document.getElementById('prevPage');
const nextPageButton = document.getElementById('nextPage');

prevPageButton.addEventListener('click', () => {
    if (currentPage > 1) {
        currentPage--;
        showItems(currentPage);
    }
});

nextPageButton.addEventListener('click', () => {
    const totalItems = ul.querySelectorAll('li').length;
    const totalPages = Math.ceil(totalItems / itemsPerPage);
    if (currentPage < totalPages) {
        currentPage++;
        showItems(currentPage);
    }
});

