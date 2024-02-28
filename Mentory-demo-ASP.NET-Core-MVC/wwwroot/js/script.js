const userForm = document.getElementById('user-form');
const output = document.getElementById('output');

userForm.addEventListener('submit', async function (e) {
    e.preventDefault();
    const jsonResponse = await fetch('/user', {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            FirstName: userForm.firstName.value,
            LastName: userForm.lastName.value
        })
    })
        .then(response => response.json());
    output.innerText = jsonResponse.message;
});

const getImageButton = document.getElementById('get-image');
const imageOutput = document.getElementById('image-output');

getImageButton.addEventListener('click', getImage);

async function getImage() {
    const imageResponse = await fetch('/image', {
        method: "GET"
    })
        .then(response => response.blob());
    const imageUrl = URL.createObjectURL(imageResponse);
    imageOutput.src = imageUrl;
}

const uploadForm = document.getElementById('image-upload-form');
const uploadOutput = document.getElementById('image-upload-output');

uploadForm.addEventListener('submit', postImage);

async function postImage(event) {
    event.preventDefault();
    const formData = new FormData(uploadForm);
    const jsonResponse = await fetch('/image', {
        method: "POST",
        body: formData
    })
        .then(response => response.json());
    getImage();
}