import { Injectable } from '@angular/core';
import { Http, Response }          from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { RssFeed } from '../model/rss-feed.object';


@Injectable()
export class FetchRssFeedsService {
    private apiUrl = 'api/RssFeeds';

    constructor (private http: Http) {}

    public getRssFeeds(): Observable<RssFeed[]> {
        return this.http.get(this.apiUrl)
                        .map(this.extractData)
                        .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError (error: Response | any) {
        console.error("Failed to fetch RSS Feed data");
        return Observable.throw("Failed to fetch RSS feed data");
    }

}