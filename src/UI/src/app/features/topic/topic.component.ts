import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink, RouterOutlet } from '@angular/router';
import { TopicsService } from '../services/topics.service';
import { ITopic } from '../models/topic.model';
import { CommonModule } from '@angular/common';
import { MatButton, MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-topic',
  standalone: true,
  imports: [CommonModule, MatButtonModule, RouterOutlet, RouterLink],
  templateUrl: './topic.component.html',
  styleUrl: './topic.component.scss'
})
export class TopicComponent implements OnInit{

  
  showError : boolean = false;
  value : ITopic | null = null;
  constructor(private activateRoute: ActivatedRoute, private topicsService : TopicsService){
    
  }

  ngOnInit(): void {
    const id = this.activateRoute.params.subscribe({
      next : data =>{
        const id = data["id"];
        this.load(id);
      }
    })
  }

  private load(id : number){
    this.topicsService.getById(id)
      .subscribe({
        next : data => {
          this.value = data;
          this.showError = false;
        },
        error : () => {
          this.showError = true;
        }
      })
  }
}
