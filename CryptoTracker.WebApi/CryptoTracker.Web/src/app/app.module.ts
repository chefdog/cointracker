import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './app.component';
import { MiniStatsComponent } from './mini-stats/mini-stats.component';
import { PortfolioComponent } from './portfolio/portfolio.component';
import { MiniStatCoinsComponent } from './mini-stat-coins/mini-stat-coins.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppRoutingModule } from './app-routing.module';
import { MessagesComponent } from './messages/messages.component';

import { PortfolioService } from './portfolio.service';
import { StatisticsService } from './statistics.service';


@NgModule({
  declarations: [
    AppComponent,
    MiniStatsComponent,
    PortfolioComponent,
    MiniStatCoinsComponent,
    DashboardComponent,
    MessagesComponent
  ],
  imports: [
    BrowserModule, AngularFontAwesomeModule, AppRoutingModule, HttpClientModule
  ],
  providers: [PortfolioService, StatisticsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
