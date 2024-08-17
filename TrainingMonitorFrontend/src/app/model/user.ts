import { Training } from "./training";

export class User {
    email?: any;
    name?: any;
    surname?: any;
    gender?: any;
    trainings?: Training[];
}

export function convertGenderEnumToString(genderEnum: number): string {
    switch (genderEnum) {
        case 0:
            return 'Male';
        case 1:
            return 'Female';
        case 2:
            return 'Other';
        default:
            return 'Unknown';
    }
}