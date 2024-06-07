let localRadio = document.getElementById('localRadio');
let dbRadio = document.getElementById('dbRadio');

let localSettings = document.getElementById('localPath');
let dbSettings = document.querySelectorAll('.dbSettings');

function updateReadonlyState() {
    if (localRadio.checked) {
        localSettings.removeAttribute('readonly');
        dbSettings.forEach(x => {
            x.setAttribute('readonly', 'readonly');
        });
    } else if (dbRadio.checked) {
        localSettings.setAttribute('readonly', 'readonly');
        dbSettings.forEach(x => {
            x.removeAttribute('readonly');
        });
    }
}

localRadio.addEventListener('click', updateReadonlyState);
dbRadio.addEventListener('click', updateReadonlyState);

updateReadonlyState();
