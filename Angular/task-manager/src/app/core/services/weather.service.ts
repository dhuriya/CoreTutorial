import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map, catchError, of} from 'rxjs';
import { environment} from '../../../environments/environment'

export interface WeatherData{
  city: string;
  temp: number;
  feelsLike: number;
  description: string;
  icon: string;
  humidity: number;
  windSpeed:number
}
@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  private http = inject(HttpClient);

  getWeather(city: string): Observable<WeatherData | null> {
    const url = `${environment.weatherApiUrl}/weather?q=${city}&appid=${environment.weatherApiKey}&units=metric`;

    return this.http.get<any>(url).pipe(
      map(res => ({
        city: res.name,
        temp: Math.round(res.main.temp),
        feelsLike: Math.round(res.main.feels_like),
        description: res.weather[0].description,
        icon: `https://openweathermap.org/img/wn/${res.weather[0].icon}@2x.png`,
        humidity: res.main.humidity,
        windSpeed: res.wind.speed
      })),
      catchError(err => {
        console.error('Weather API error:', err);
        return of(null);  // error pe null return — UI handle karega
      })
    );
  }
}

// Har part ka reason:

// Part	                               Kyu
// HttpClient inject	              Angular ka HTTP client — API call ke liye
// Observable<WeatherData>	        Async data — RxJS ka stream
// map(res => ...)	                API ka raw response ko hamare WeatherData shape me convert karo (transformation)
// catchError	                      Error aaye toh app crash na ho — gracefully handle
// of(null)	                        Error pe null value return — UI "weather unavailable" dikha sakta
// units=metric	                    Temperature Celsius me chahiye (Fahrenheit nahi)
// API URL pattern	                OpenWeatherMap ka standard endpoint
