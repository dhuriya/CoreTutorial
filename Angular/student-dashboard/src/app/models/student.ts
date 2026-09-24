export type Gender = 'Male' | 'Female';
export type StudentFilter = 'All' | Gender;

export interface Student {
    ID: string;
    FisrtName: string;
    LastName: string;
    DOB: Date;
    Gender: Gender;
    CourseFee: number;
}