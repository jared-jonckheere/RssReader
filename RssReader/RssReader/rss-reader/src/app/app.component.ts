import { Component, OnInit } from '@angular/core';

import { RssFeed } from '../model/rss-feed.object';
import { FetchRssFeedsService } from './fetch-rss-feeds.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private rssFeeds: RssFeed[] = [];
  private title = 'app works!';

  constructor(private fetchRssFeedsService: FetchRssFeedsService) {}

  ngOnInit() {
    this.fetchRssFeedsService.getRssFeeds().subscribe((feeds: RssFeed[]) => this.rssFeeds = feeds);
  }
}
