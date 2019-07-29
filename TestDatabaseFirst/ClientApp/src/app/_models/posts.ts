import { User } from "./user";
import { PostComments } from "./postcomments";
import { PostLikes } from "./postlikes";

export class Posts {
  PostId: Number;
  Content: String;
  ImageUrl: String;
  CreatedAt: Date;
  UpdatedAt: Date;
  UserId: Number;

  User: User;
  PostComments: [PostComments];
  PostLikes: [PostLikes];
}
