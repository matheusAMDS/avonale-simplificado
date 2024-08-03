export interface ActionResult<T = {}> {
  success: boolean
  error?: string
  data?: T
}
