function RegisterNewUser() {
    var newUser = {
        Id: "00000000-0000-0000-0000-000000000000",
        FullName: $('#fullName').val().trim(),
        UserName: $('#userName').val().trim(),
        Email: $('#email').val().trim(),
        Password: $('#password').val()
    };

    $('.error-label').text('');

    if (!validateInputs(newUser)) {
        return;
    }

    $.ajax({
        type: "POST",
        url: `/Register?handler=RegisterNewUser`,
        headers: {
            "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val(),
            "Content-Type": "application/json"
        },
        data: JSON.stringify(newUser),
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

function validateInputs(data) {
    var isValid = true;

    if (!data.FullName || data.FullName.length < 2) {
        $('#fullNameError').text('Full Name must be at least 2 characters long.');
        isValid = false;
    }
    if (!data.UserName || data.UserName.length < 2) {
        $('#userNameError').text('User Name must be at least 2 characters long.');
        isValid = false;
    }
    if (!data.Email || !validateEmail(data.Email)) {
        $('#emailError').text('Please enter a valid email address.');
        isValid = false;
    }
    if (!data.Password || data.Password.length < 6) {
        $('#passwordError').text('Password must be at least 6 characters long.');
        isValid = false;
    }
    else {
        var confirmPasswordValue = document.getElementById("confirmPassword").value;
        if (data.Password != confirmPasswordValue) {
            $('#confirmPasswordError').text('Both passwords must match.');
            isValid = false;
        }
    }
    return isValid;
}

function validateEmail(email) {
    var re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
}