import { InspectionD } from './inspectiond';
import { TaskSchedule } from './taskSchedule';
import { Locations } from './locations';

export interface InspectionDetails {

    inspectionD: InspectionD;

    taskSchedule: TaskSchedule;

    locations: Locations;
}
