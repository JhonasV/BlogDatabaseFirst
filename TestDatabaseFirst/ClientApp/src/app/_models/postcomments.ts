import { Posts } from "./posts";
import { User } from "./user";

export class PostComments {
  PostCommentId: Number;
  Content: String;
  PostId: Number;
  UserId: Number;
  CreatedAt?: Date;
  UpdatedAt?: Date;

  Post: Posts;
  User: User;
}
