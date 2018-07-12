import { Component, OnInit } from '@angular/core';
import { StatModel } from '../models/statModel';
import { StatisticsService } from '../statistics.service';

@Component({
  selector: 'app-mini-stats',
  templateUrl: './mini-stats.component.html',
  styleUrls: ['./mini-stats.component.scss']
})
export class MiniStatsComponent implements OnInit {

  stats: StatModel[];
  
  constructor(private statisticsService: StatisticsService) { }

  ngOnInit() {
  }

  getStatistics(): void{
    this.statisticsService.getStats()
    .subscribe(stats => this.stats = stats);
  }

}
