import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { UsersService } from "../_services/users.service";
import { first } from "rxjs/operators";
import { User } from "../_models/user";
@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"]
})
export class RegisterComponent implements OnInit {
  constructor(private userService: UsersService) {}

  registerForm = new FormGroup({
    username: new FormControl("", Validators.required),
    userpassword: new FormControl("", Validators.required)
  });
  ngOnInit() {}
  onSubmit() {
    if (this.registerForm.invalid) return;
    let formValues = this.registerForm.value;
    let newUser = new User();
    newUser.username = formValues.username;
    newUser.password = formValues.userpassword;
    this.userService
      .createUser(newUser)
      .pipe(first())
      .subscribe(
        res => {
          console.log(res);
        },
        error => {
          console.log(error);
        }
      );
  }
}
