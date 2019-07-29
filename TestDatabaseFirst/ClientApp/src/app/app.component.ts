import { Component } from "@angular/core";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styles: [
    `
      .active {
        background-color: red;
      }
    `
  ]
})
export class AppComponent {
  title = "ClientApp";
  persona = {
    nombre: "Luis",
    edad: 20
  };
}
