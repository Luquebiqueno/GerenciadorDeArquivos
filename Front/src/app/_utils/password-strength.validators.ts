import { AbstractControl, ValidationErrors } from "@angular/forms"

export const PasswordStrengthValidator = function (control: AbstractControl): ValidationErrors | null {

    let value: string = control.value || '';

    if (!value) {
        return null
    }

    let lowerCaseCharacters = /[a-z]+/g
    if (lowerCaseCharacters.test(value) === false) {
        return { passwordStrength: 'Caractere minúsculo obrigatório.' };
    }

    let upperCaseCharacters = /[A-Z]+/g
    if (upperCaseCharacters.test(value) === false) {
        return { passwordStrength: 'Caractere maiúsculo obrigatório' };
    }

    let numberCharacters = /[0-9]+/g
    if (numberCharacters.test(value) === false) {
        return { passwordStrength: 'Caractere numérico obrigatório.' };
    }

    let specialCharacters = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/
    if (specialCharacters.test(value) === false) {
        return { passwordStrength: 'Caractere especial obrigatório.' };
    }

    if (value.length < 8) {
        return { passwordStrength: 'Obrigatório no mínimo 8 caracteres.' };
    }
    return null;
}