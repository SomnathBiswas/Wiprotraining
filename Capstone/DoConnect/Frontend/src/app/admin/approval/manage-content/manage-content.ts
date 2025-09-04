import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { Router } from '@angular/router';

interface QItem {
  questionId: number;
  questionTitle: string;
  questionText: string;
  status: 'Pending'|'Approved'|'Rejected';
  createdAt: string;
  username: string;
}
interface AItem {
  answerId: number;
  questionId: number;
  questionTitle: string;
  answerText: string;
  status: 'Pending'|'Approved'|'Rejected';
  createdAt: string;
  username: string;
}

@Component({
  selector: 'app-manage-content',
  standalone: false,
  templateUrl: './manage-content.html',
  styleUrl: './manage-content.css'
})
export class ManageContent {
  tab: 'questions'|'answers' = 'questions';
  search = '';
  filterStatus: 'All'|'Pending'|'Approved'|'Rejected' = 'All';

  qItems: QItem[] = [];
  aItems: AItem[] = [];
  qFiltered: QItem[] = [];
  aFiltered: AItem[] = [];

  private api = axios.create({ baseURL: 'http://localhost:5081/api' });

  constructor(private router: Router) {
    this.api.interceptors.request.use(c => {
      const t = localStorage.getItem('authToken');
      if (t) c.headers.Authorization = `Bearer ${t}`;
      return c;
    });
  }

  ngOnInit(): void { this.reload(); }

  async reload() {
    // TODO: change to your API endpoints
    const qs = await this.api.get<QItem[]>('/QuestionApi'); // returns all
    const as = await this.api.get<AItem[]>('/AnswerApi');   // returns all
    this.qItems = qs.data;
    this.aItems = as.data;
    this.filter();
  }

  filter() {
    const s = this.search.toLowerCase();

    this.qFiltered = this.qItems.filter(q => {
      const st = this.filterStatus === 'All' || q.status === this.filterStatus;
      const se = q.questionTitle.toLowerCase().includes(s) ||
                 q.questionText.toLowerCase().includes(s) ||
                 q.username.toLowerCase().includes(s);
      return st && se;
    });

    this.aFiltered = this.aItems.filter(a => {
      const st = this.filterStatus === 'All' || a.status === this.filterStatus;
      const se = a.answerText.toLowerCase().includes(s) ||
                 a.username.toLowerCase().includes(s) ||
                 a.questionTitle.toLowerCase().includes(s);
      return st && se;
    });
  }

  async deleteQuestion(id: number) {
    if (!confirm('Delete this question?')) return;
    await this.api.delete(`/QuestionApi/${id}`);  // Admin-only in backend
    await this.reload();
  }

  async deleteAnswer(id: number) {
    if (!confirm('Delete this answer?')) return;
    await this.api.delete(`/AnswerApi/${id}`);    // Admin-only in backend
    await this.reload();
  }

  logout() {
    localStorage.removeItem('authToken');
    this.router.navigateByUrl('/');
  }
}
