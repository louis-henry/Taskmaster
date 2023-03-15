const customSelects = document.querySelectorAll("select");
const deleteBtn = document.getElementById('delete')
const toggleAdvancedButton = document.getElementById('advanced-search-button')
const choices = new Choices('select',
    {
        searchEnabled: false,
        removeItemButton: true,
        itemSelectText: '',
    });
for (let i = 0; i < customSelects.length; i++) {
    customSelects[i].addEventListener('addItem', function (event) {
        if (event.detail.value) {
            let parent = this.parentNode.parentNode
            parent.classList.add('valid')
            parent.classList.remove('invalid')
        }
        else {
            let parent = this.parentNode.parentNode
            parent.classList.add('invalid')
            parent.classList.remove('valid')
        }
    }, false);
}
deleteBtn.addEventListener("click", function (e) {
    e.preventDefault()
    const deleteAll = document.querySelectorAll('.choices__button')
    for (let i = 0; i < deleteAll.length; i++) {
        deleteAll[i].click();
    }
    document.getElementById('adv-s-min').value = "";
    document.getElementById('adv-s-max').value = "";
    document.getElementById('adv-s-pcode').value = "";
});
toggleAdvancedButton.addEventListener("click", function (e) {
    e.preventDefault()
    const toggleAdvancedArea = document.getElementById('advanced-search-area')
    const isVisible = toggleAdvancedArea.style.display;
    if (isVisible == 'block') {
        toggleAdvancedArea.style.display = 'none';
    } else {
        toggleAdvancedArea.style.display = 'block';
    }
});
