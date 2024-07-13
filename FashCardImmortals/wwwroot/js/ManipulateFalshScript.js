function RegisterSubCategory() {
    var categoryName = $('#new-category-name').val().trim();

    if (!categoryName) {
        $('#errorMessage').text('Category name cannot be empty.');
        return;
    }

    if (categoryName.length < 3) {
        $('#errorMessage').text('Category name must be at least 3 characters long.');
        return;
    }

    var newSubCategory = {
        Name: categoryName
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
                PopUpDisplay();
            } else {
                $('#errorMessage').text(response.error);
            }
        },
        error: function (error) {
            console.error('Error sending data:', error);
            $('#errorMessage').text('An error occurred while processing your request.');
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