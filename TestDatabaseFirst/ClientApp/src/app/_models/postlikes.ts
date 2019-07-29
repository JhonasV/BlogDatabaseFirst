import { Posts } from "./posts";
import { User } from "./user";

export class PostLikes {
  PostlikesId: Number;
  UserId: Number;
  PostId: Number;
  CreatedAt: Date;

  Post: Posts;
  User: User;
}
