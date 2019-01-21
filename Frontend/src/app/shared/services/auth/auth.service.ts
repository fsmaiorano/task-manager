import { Injectable } from "@angular/core";
import { HttpClient, HttpResponse } from "@angular/common/http";

import { environment } from "src/environments/environment";
import { Auth } from "../../models/auth.model";

import { Observable, throwError } from "rxjs";
import { map, catchError } from "rxjs/operators";
import { ApiResponse } from "../../models/api-response.model";
import { User } from "../../models/user.model";

@Injectable({
    providedIn: "root"
})
export class AuthService {
    constructor(private http: HttpClient) {}

    signin(auth: Auth): Observable<User> {
        return this.http.post(`${environment.apiUrl}/api/user/signin`, auth).pipe(
            map((res: ApiResponse) => {
                if (res.status === 200) {
                    return res.content as User;
                }
                throw new Error(res.message);
            })
        );
    }
}
