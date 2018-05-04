import { User } from '../models/User';

export interface AuthUser {
  tokenString: string;
  user: User;
}
