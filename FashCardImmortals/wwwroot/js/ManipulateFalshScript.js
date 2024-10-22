﻿function RegisterSubCategory(mainCategoryId) {
    var categoryName = $('#new-category-name-input').val().trim();

    if (!categoryName) {
        $('#errorMessage').text('Category name cannot be empty.');
        return;
    }

    if (categoryName.length < 3) {
        $('#errorMessage').text('Category name must be at least 3 characters long.');
        return;
    }

    var newSubCategory = {
        Name: categoryName,
        MainCategoryId: mainCategoryId
    };

    $.ajax({
        type: "POST",
        url: `/ManipulateFlash?handler=RegisterSubCategory`,
        headers: {
            "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val(),
            "Content-Type": "application/json"
        },
        data: JSON.stringify(newSubCategory),
        success: function (response) {
            if (response.success) {
                Toastify({
                    text: "Subcategory registered successfully!",
                    duration: 3000,
                    gravity: "bottom",
                    position: "right",
                    backgroundColor: "#4CAF50",
                }).showToast();
                InjectCategories(response.numberOfSubCategories, categoryName, response.id);
                InjectCategoryNameIntoList(categoryName, response.id);
                PopUpDisplay();
            } else {
                Toastify({
                    text: response.error,
                    duration: 3000,
                    gravity: "bottom",
                    position: "right",
                    backgroundColor: "#ff6b6b",
                }).showToast();
            }
        },
        error: function (error) {
            console.error('Error sending data:', error);
            Toastify({
                text: "An error occurred while processing your request.",
                duration: 3000,
                gravity: "bottom",
                position: "right",
                backgroundColor: "#ff6b6b",
            }).showToast();
        }
    });
}

function RegisterNewFlashCard() {
    var question = $('#question-input').val().trim();
    var answer = $('#answer-input').val().trim();
    var subCategoryValue = $('#sub-category-input option:selected').val().trim().split('/');
    var subCategoryName = subCategoryValue[0];
    var subCategoryId = subCategoryValue[1];

    var newFlashCard = {
        SubCategoryId: subCategoryId,
        Question: question,
        Answer: answer
    };

    $.ajax({
        type: "POST",
        url: `/ManipulateFlash?handler=RegisterNewFlashCard`,
        headers: {
            "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val(),
            "Content-Type": "application/json"
        },
        data: JSON.stringify(newFlashCard),
        success: function (response) {
            if (response.success) {
                Toastify({
                    text: "Flashcard registered successfully!",
                    duration: 3000,
                    gravity: "bottom",
                    position: "right",
                    backgroundColor: "#4CAF50",
                }).showToast();
                InjectNewFlashCard(question, answer, subCategoryName, response.id);
            } else {
                Toastify({
                    text: response.error,
                    duration: 3000,
                    gravity: "bottom",
                    position: "right",
                    backgroundColor: "#ff6b6b",
                }).showToast();
            }
        },
        error: function (error) {
            console.error('Error sending data:', error);
            Toastify({
                text: "An error occurred while processing your request.",
                duration: 3000,
                gravity: "bottom",
                position: "right",
                backgroundColor: "#ff6b6b",
            }).showToast();
        }
    });
}

function PopUpDisplay() {
    var popUpElement = document.getElementById("popup");
    var overlayElement = document.getElementById("overlay");
    if (popUpElement.style.display === "none" || popUpElement.style.display === "") {
        popUpElement.style.display = "flex";
        overlayElement.style.display = "block";
        overlayElement.focus();
        disableTabbing(true);
    } else {
        popUpElement.style.display = "none";
        overlayElement.style.display = "none";
        disableTabbing(false);
    }
}

function disableTabbing(disable) {
    const focusableElements = document.querySelectorAll('button, [href], input, select, textarea, [tabindex]:not([tabindex="-1"])');
    focusableElements.forEach(el => {
        if (disable) {
            if (!el.closest('#popup')) {
                el.setAttribute('tabindex', '-1');
            }
        } else {
            el.removeAttribute('tabindex');
        }
    });
}

document.addEventListener('keydown', function (event) {
    var popUpElement = document.getElementById("popup");
    if (popUpElement.style.display === "flex") {
        var focusableElements = popUpElement.querySelectorAll('button, [href], input, select, textarea, [tabindex]:not([tabindex="-1"])');
        var firstElement = focusableElements[0];
        var lastElement = focusableElements[focusableElements.length - 1];

        if (event.key === 'Tab') {
            if (event.shiftKey) {
                if (document.activeElement === firstElement) {
                    lastElement.focus();
                    event.preventDefault();
                }
            } else {
                if (document.activeElement === lastElement) {
                    firstElement.focus();
                    event.preventDefault();
                }
            }
        } else if (event.key === 'Escape') {
            PopUpDisplay();
        }
    }
});

function flipCard(cardId) {
    var card = document.getElementById(cardId);
    card.classList.toggle('flipped');
}

function InjectCategoryNameIntoList(subCategoryName, subCategoryId) {
    var subCategoryList = document.getElementById('sub-category-input');
    var newOption = document.createElement('option');
    newOption.value = `${subCategoryName}/${subCategoryId}`;
    newOption.text = subCategoryName;
    subCategoryList.appendChild(newOption);
}

function CalculateWhereToAddCategory(numberOfSubCategories) {
    if (numberOfSubCategories <= 4) {
        return 1;
    }
    if (numberOfSubCategories >= 9) {
        return null;
    }
    return 2;
}

function InjectCategories(numberOfSubCategories, subCategoryName, subCategoryId) {
    var whereToAdd = CalculateWhereToAddCategory(numberOfSubCategories);

    if (whereToAdd == null)
        return;

    var divToAddSubCategory = document.getElementById(`category-flex-${whereToAdd}`);

    var htmlContent = `
        <div class="category-content-containers">
            <h3 class="sub-category-headings">${subCategoryName}</h3>
            <hr />
            <div class="flash-cards-in-${subCategoryId}">
            </div>
        </div>`;

    divToAddSubCategory.insertAdjacentHTML('beforeend', htmlContent);
}

function InjectNewFlashCard(question, answer, subCategoryName, flashCardId) {
    var flashCardContainer = document.getElementById(`flash-cards-in-${subCategoryName}`);

    var htmlContent = `
        <div class="flash-cards">
            <div class="flash-card-inner" id="flash-card-inner-${flashCardId}">
                <div class="flash-card-front">
                    <h5 class="sub-category-headings">Question:</h5>
                    <label class="flash-card-contents">${question}</label>
                    <br /><br />
                    <button class="button" onclick="flipCard('flash-card-inner-${flashCardId}')">Swap</button>
                    <br />
                </div>
                <div class="flash-card-back">
                    <h5 class="sub-category-headings">Answer:</h5>
                    <label class="flash-card-contents">${answer}</label>
                    <br /><br />
                    <button class="button" onclick="flipCard('flash-card-inner-${flashCardId}')">Swap</button>
                    <br />
                </div>
            </div>
        </div>
        <br />
        <br />`;

    flashCardContainer.insertAdjacentHTML('beforeend', htmlContent);
}