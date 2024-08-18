export class Training {
    id?: string;
    trainingDateTime?: Date;
    intensity?: number;
    fatigue?: number;
    durationInMinutes?: number;
    caloriesSpent?: number;
    trainingType?: any;
    userId?: string;
    trainingDateString: string | undefined;
  }

  export function convertTrainingTypeToString(type: number): string {
    switch (type) {
        case 0:
            return 'Cardio';
        case 1:
            return 'Strength';
        case 2:
            return 'Flexibility';
        case 3:
            return 'Functional';
        default:
            return 'Unknown';
    }
}