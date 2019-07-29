import { HttpClient } from "@angular/common/http";
import { Posts } from "../_models/posts";
import { Injectable } from "@angular/core";
@Injectable({ providedIn: "root" })
export class PostsService {
  private apiURL = "http://localhost:61841/api/v1";

  constructor(private http: HttpClient) {}
  create(post: Posts) {
    return this.http.post(`${this.apiURL}/posts`, post);
  }

  get() {
    return this.http.get<[Posts]>(`${this.apiURL}/posts`);
  }
}
