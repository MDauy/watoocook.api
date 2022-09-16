import { Component, OnInit } from '@angular/core';
import { Recipe } from './recipe.model';

@Component({
  selector: 'recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.css']
})
export class RecipeComponent implements OnInit {
  recipe: Recipe = {
    title: 'My recipe',
    ingredients: []
  }
  constructor() { }

  ngOnInit(): void {
  }

}
