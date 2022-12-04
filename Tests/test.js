import http from 'k6/http';
import {check, sleep} from 'k6';


export default function () {
    const res = http.get('http://20.94.22.52:5000/api/v1/contracts/41bfbbe0-7762-4fb4-a046-057c72e2325a');
    check(res, {'status was 200': (r) => r.status === 200});
}
