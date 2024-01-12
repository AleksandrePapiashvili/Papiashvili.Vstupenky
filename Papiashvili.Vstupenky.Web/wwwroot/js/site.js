// Получаем все элементы с классом concert-image
const concertImages = document.querySelectorAll('.concert-image');

// Устанавливаем максимальную длину для src
const maxLength = 50;

// Проходимся по каждому элементу концерта с изображением
concertImages.forEach(image => {
    let src = image.getAttribute('src');

    // Проверяем длину src и укорачиваем, если она больше maxLength
    if (src.length > maxLength) {
        let shortenedSrc = src.substring(0, maxLength) + '...'; // Укорачиваем до maxLength и добавляем многоточие
        image.setAttribute('src', shortenedSrc); // Устанавливаем новое значение src
    }
});
 