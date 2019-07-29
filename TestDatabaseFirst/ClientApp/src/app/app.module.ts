import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { ReactiveFormsModule } from "@angular/forms";
import { AppComponent } from "./app.component";
import { PostsComponent } from "./posts/posts.component";
import { RegisterComponent } from "./register/register.component";
import { LoginComponent } from "./login/login.component";
import { UsersService } from "./_services/users.service";
import { HttpClientModule } from "@angular/common/http";
import { PostsService } from "./posts.service";
@NgModule({
  declarations: [
    AppComponent,
    PostsComponent,
    RegisterComponent,
    LoginComponent
  ],
  imports: [BrowserModule, FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [UsersService, PostsService],
  bootstrap: [AppComponent]
})
export class AppModule {}
