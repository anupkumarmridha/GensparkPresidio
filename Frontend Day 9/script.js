const predefinedProfessions = ["Doctor", "Engineer", "Teacher", "Lawyer"];

const professionDatalist = document.getElementById('professions');
predefinedProfessions.forEach(profession => {
    const option = document.createElement('option');
    option.value = profession;
    professionDatalist.appendChild(option);
});


function calculateAge() {
    const dob = document.getElementById('dob').value;
    if (dob) {
        const birthDate = new Date(dob);
        const today = new Date();
        let age = today.getFullYear() - birthDate.getFullYear();
        const monthDifference = today.getMonth() - birthDate.getMonth();
        if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < birthDate.getDate())) {
            age--;
        }
        document.getElementById('age').value = age;
        document.getElementById('dobError').innerText = '';
        document.getElementById('dob').classList.remove('error-border');
        document.getElementById('dob').classList.add('success-border');
    } else {
        document.getElementById('dobError').innerText = 'Please enter your date of birth.';
        document.getElementById('dob').classList.remove('success-border');
        document.getElementById('dob').classList.add('error-border');

    }
}

function validateName() {
    const name = document.getElementById('name').value;
    if (name.trim() === '') {
        document.getElementById('nameError').innerText = 'Name is required.';
        document.getElementById('name').classList.remove('success-border');
        document.getElementById('name').classList.add('error-border');
        return false;
    } else {
        document.getElementById('nameError').innerText = '';
        document.getElementById('name').classList.remove('error-border');
        document.getElementById('name').classList.add('success-border');
        return true;
    }
}

function validatePhone() {
    const phone = document.getElementById('phone').value;
    const phonePattern = /^[0-9]{10}$/;
    if (!phonePattern.test(phone)) {
        document.getElementById('phoneError').innerText = 'Please enter a valid 10-digit phone number.';
        document.getElementById('phone').classList.remove('success-border');
        document.getElementById('phone').classList.add('error-border');
        return false;
    } else {
        document.getElementById('phoneError').innerText = '';
        document.getElementById('phone').classList.remove('error-border');
        document.getElementById('phone').classList.add('success-border');
        return true;
    }
}

function validateEmail() {
    const email = document.getElementById('email').value;
    const emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
    if (!emailPattern.test(email)) {
        document.getElementById('emailError').innerText = 'Please enter a valid email address.';
        document.getElementById('email').classList.remove('success-border');
        document.getElementById('email').classList.add('error-border');
        return false;
    } else {
        document.getElementById('emailError').innerText = '';
        document.getElementById('email').classList.remove('error-border');
        document.getElementById('email').classList.add('success-border');
        return true;
    }
}

function validateProfession() {
    const profession = document.getElementById('profession').value;
    const professionError = document.getElementById('professionError');
    const professionInput = document.getElementById('profession');

    if (profession.trim() === '') {
        professionError.innerText = 'Profession cannot be empty.';
        professionInput.classList.remove('success-border');
        professionInput.classList.add('error-border');
        return false;
    } else if (!predefinedProfessions.includes(profession)) {
        professionError.innerText = 'Invalid profession.';
        professionInput.classList.remove('success-border');
        professionInput.classList.add('error-border');
        return false;
    } else {
        professionError.innerText = '';
        professionInput.classList.remove('error-border');
        professionInput.classList.add('success-border');
        return true;
    }
}

function validateForm() {

    // clear the previous error messages
    document.getElementById('nameError').innerText = '';
    document.getElementById('phoneError').innerText = '';
    document.getElementById('emailError').innerText = '';
    document.getElementById('dobError').innerText = '';
    document.getElementById('genderError').innerText = '';
    document.getElementById('qualificationError').innerText = '';
    document.getElementById('professionError').innerText = '';


    const isNameValid = validateName();
    const isPhoneValid = validatePhone();
    const isEmailValid = validateEmail();
    const dob = document.getElementById('dob').value;
    const gender = document.querySelector('input[name="gender"]:checked');
    const qualifications = document.querySelectorAll('input[name="qualification"]:checked');
    const profession = document.getElementById('profession').value;

    let isFormValid = true;

    if (!dob) {
        document.getElementById('dobError').innerText = 'Please enter your date of birth.';

        document.getElementById('dob').classList.remove('success-border');
        document.getElementById('dob').classList.add('error-border');
        isFormValid = false;
    } else {
        document.getElementById('dobError').innerText = '';
        document.getElementById('dob').classList.remove('error-border');
        document.getElementById('dob').classList.add('success-border');
    }

    if (!gender) {
        document.getElementById('genderError').innerText = 'Please select your gender.';
        isFormValid = false;
    } else {
        document.getElementById('genderError').innerText = '';
    }

    if (qualifications.length === 0) {
        document.getElementById('qualificationError').innerText = 'Please select at least one qualification.';
        isFormValid = false;
    } else {
        document.getElementById('qualificationError').innerText = '';
    }

    if (profession.trim() === '') {
        document.getElementById('professionError').innerText = 'Please select or enter your profession.';
        document.getElementById('profession').classList.remove('success-border');
        document.getElementById('profession').classList.add('error-border');
        isFormValid = false;
    } else {
        validateProfession();
        document.getElementById('professionError').innerText = '';
        document.getElementById('profession').classList.remove('error-border');
        document.getElementById('profession').classList.add('success-border');
    }

    if (isFormValid && isNameValid && isPhoneValid && isEmailValid) {
        // clear the form fields if the form is valid
        document.getElementById('registrationForm').reset();
        showToast();
    }
}

function showToast() {
    const toast = document.getElementById("toast");
    toast.className = "toast show";
    setTimeout(function () {
        toast.className = toast.className.replace("show", "");
    }, 3000);


    var closeButton = document.querySelector('.toast .close');
    closeButton.onclick = function () {
        var toast = this.parentElement;
        toast.style.visibility = 'hidden';
    };
}