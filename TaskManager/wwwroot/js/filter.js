let filter = document.getElementById('filter');
let filterBtns = document.querySelectorAll('.filterBtn');

filterBtns.forEach(filterBtn => {

    console.log(filterBtn)

    filterBtn.addEventListener('click', () => {

        console.log('TEST');
        filter.classList.toggle('d-none');

        filterBtns.forEach(filterBtn => {
            filterBtn.classList.toggle('d-none');
        })
    });
})

