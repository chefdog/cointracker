import { Component, OnInit } from '@angular/core';
import { StatModel } from '../models/statModel';
import { STATS } from '../mock-data/mock-stats';

@Component({
  selector: 'app-mini-stats',
  templateUrl: './mini-stats.component.html',
  styleUrls: ['./mini-stats.component.scss']
})
export class MiniStatsComponent implements OnInit {

  stats = STATS;
  
  constructor() { }

  ngOnInit() {
  }

}
