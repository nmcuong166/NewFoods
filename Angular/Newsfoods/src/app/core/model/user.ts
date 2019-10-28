﻿
export class User {
    id: number;
    username: string;
    password: string;
    firstName: string;
    lastName: string;
    token?: string;
}
export interface Login {
    userName: string;
    passWord: string;
}