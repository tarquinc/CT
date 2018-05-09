import { User } from '../models/User';

export interface AuthUser {
  token: string;
  user: User;
}
