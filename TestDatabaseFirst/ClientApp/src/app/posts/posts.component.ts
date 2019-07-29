import { Component, OnInit } from "@angular/core";
import { PostsService } from "../_services/posts.service";
import { first } from "rxjs/operators";
import { Posts } from "../_models/posts";

@Component({
  selector: "app-posts",
  templateUrl: "./posts.component.html",
  styleUrls: ["./posts.component.css"]
})
export class PostsComponent implements OnInit {
  constructor(private postsService: PostsService) {}
  posts: [Posts];
  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.postsService
      .get()
      .pipe(first())
      .subscribe(
        res => (this.posts = res) && console.table(res),
        error => console.log(error)
      );
  }
}
