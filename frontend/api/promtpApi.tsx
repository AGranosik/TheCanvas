import axios from 'axios'
import { _baseUrl } from './common'

const _promptEndpoint = '/Images/Prompt'

export const getPromptResponse = (prompt: string) => {
    return axios.post<string>(_baseUrl + _promptEndpoint,{
        prompt: prompt
    })
}