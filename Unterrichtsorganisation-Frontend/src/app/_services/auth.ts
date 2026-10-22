import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private apiUrl = 'http://localhost:8080/api/auth';

    constructor(private http: HttpClient) { }

    login(username: string, password: string) {
        return this.http.post<any>(`${this.apiUrl}/login`, {
            username,
            password
        }).pipe(
            tap(response => {
                localStorage.setItem('accessToken', response.accessToken);

                // Falls eine Rolle zurückkommt
                if (response.role) {
                    localStorage.setItem('role', response.role);
                }
            })
        );
    }

    getToken(): string | null {
        return localStorage.getItem('accessToken');
    }

    getRole(): string | null {
        return localStorage.getItem('role');
    }

    logout(): void {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('role');
    }
}