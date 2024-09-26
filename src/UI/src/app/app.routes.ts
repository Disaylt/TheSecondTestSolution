import { Routes } from '@angular/router';
import { TopicComponent } from './features/topic/topic.component';
import { TopicsComponent } from './features/topics/topics.component';

export const routes: Routes = [
    {
        path : "topic/:id",
        component : TopicComponent
    },
    {
        path : "topics",
        component : TopicsComponent
    },
    {
        path:"**", 
        redirectTo:"/topics"
    }
];
