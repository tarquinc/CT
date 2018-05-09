import { PhotoDTOCopy } from './PhotoDTOCopy';

export interface DTOCopy {
  id: number;
  userName: string;
  gender: string;
  name: string;
  age: number;
  created: Date;
  lastActive: Date;
  introduction: string
  lookingFor: string;
  interests: string;
  city: string;
  url: string;
  photos: Array<PhotoDTOCopy>;

}
