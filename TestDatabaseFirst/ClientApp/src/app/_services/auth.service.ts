import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../_models/user";
import { Observable } from "rxjs/internal/Observable";
@Injectable()
export class AuthService {
  constructor(private http: HttpClient) {}

  private apiURL = "http://localhost:61841/api/v1/";
  createUser(user: User): Observable<Boolean> {
    return this.http.post<Boolean>(this.apiURL, user);
  }
}
