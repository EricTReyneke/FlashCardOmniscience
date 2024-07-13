function LoginUser() {
    var userName = document.getElementById('userEmailUser').value;
    var password = document.getElementById('userPassword').value;

    $('.error-label').text('');

    if (!validateInputs(userName, password)) {
        return;
    }

    $.ajax({
        type: "POST",
        url: `/Login?handler=ValidateUserInfo`,
        headers: {
            "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val(),
        },
        data: {
            userName: userName,
            password: password,
        },
        dataType: "json",
        success: function (response) {
            if (response.success) {
                window.location.href = response.redirectUrl;
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

function validateInputs(userName, password) {
    var isValid = true;

    if (!userName || userName.length < 2) {
        $('#userEmailUserError').text('Username must be at least 2 characters long or enter a valid email');
        isValid = false;
    }
    if (!password || password.length < 6) {
        $('#userPasswordError').text('Password must be at least 6 characters long.');
        isValid = false;
    }
    return isValid;
}

function HideErrorMessage() {
    document.getElementById('error-message').style.display = 'none';
}