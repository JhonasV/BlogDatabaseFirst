import { User } from "../_models/user";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: "root" })
export class UsersService {
  constructor(private http: HttpClient) {}
  private apiURL = "http://localhost:61841/api/v1";

  createUser(user: User) {
    console.log(user);
    return this.http.post(`${this.apiURL}/users`, user);
  }
}
