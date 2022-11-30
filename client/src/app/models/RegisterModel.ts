export class RegisterModel {

    FirstName: string
    LastName: string
    Username: string
    Password: string
    ConfirmPassword: string

    constructor(firstName: string,
                lastName: string,
                username: string,
                password: string,
                confirmPassword: string) {
        this.FirstName = firstName
        this.LastName = lastName
        this.Username = username
        this.Password = password
        this.ConfirmPassword = confirmPassword
    }
}