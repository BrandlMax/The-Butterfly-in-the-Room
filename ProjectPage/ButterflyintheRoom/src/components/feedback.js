import React from "react"
import "../components/Feedback.css"
import "antd/dist/antd.css"
import { Tabs, Form, Input, Button, Space, Divider, Card } from "antd"
import { MinusCircleOutlined, PlusOutlined } from "@ant-design/icons"
const { TabPane } = Tabs
const { TextArea } = Input

export default function Feedback({ title, text }) {
  const layout = {}
  const tailLayout = {}

  const [form, formSug] = Form.useForm()

  // const hostname = typeof window !== "undefined" ? window.location.hostname : ""
  const onFinish = values => {
    console.log("Success:", values)

    fetch("https://butterfly.brandlmax.com/_mail/", {
      method: "POST",
      body: JSON.stringify(values),
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
    })
      .then(response => response.json())
      .then(response => {
        if (response.status === "success") {
          alert("✅ Feedback is send!")
          form.resetFields()
        } else if (response.status === "fail") {
          alert("🛑 Message failed to send. " + response.error)
        }
      })
  }

  const onFinishFailed = errorInfo => {
    console.log("Failed:", errorInfo)
  }
  return (
    <section className="feedback">
      <div className="feedbackWrapper">
        <div className="feedbackContent">
          <h2>{title}</h2>
          <p dangerouslySetInnerHTML={{ __html: text }}></p>
          {/* {hostname === "localhost" || hostname === "127.0.0.1" ? (
            <p className="localAlert">
              The form is deactivated in the local version for security reasons.
              Please visit{" "}
              <a href="https://butterfly.brandlmax.com" target="_blank">
                butterfly.brandlmax.com
              </a>{" "}
              if you want to send a message.
            </p>
          ) : undefined} */}
        </div>
        <div className="formArea">
          <Tabs defaultActiveKey="1">
            <TabPane tab="Thoughts & Feedback" key="1">
              <Form
                {...layout}
                name="basic"
                initialValues={{ remember: true }}
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                form={form}
              >
                <Form.Item
                  label="Your e-mail for further questions"
                  name="email"
                  rules={[
                    {
                      required: false,
                      type: "email",
                      message: "This is not a valid e-mail address",
                    },
                  ]}
                >
                  <Input placeholder="your@mail.com" />
                </Form.Item>

                <Form.Item
                  label="Feedback"
                  name="feedbackArea"
                  rules={[
                    {
                      required: true,
                      message: "You have forgotten to give us your feedback",
                    },
                  ]}
                >
                  <TextArea
                    placeholder="Space for your feedback & thoughts"
                    autoSize={{ minRows: 2, maxRows: 10 }}
                  />
                </Form.Item>

                <Form.Item {...tailLayout}>
                  <Button type="primary" htmlType="submit">
                    Submit
                  </Button>
                </Form.Item>
              </Form>
            </TabPane>
            <TabPane tab="Suggest a scenario" key="2">
              <p className="formIntroText">
                Here you can suggest a scenario for inside the installation.
              </p>
              <Form
                {...layout}
                name="basic"
                initialValues={{ remember: true }}
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                form={formSug}
              >
                {/* Design Desicions */}
                <Divider orientation="left">Design decisions (Cards)</Divider>
                <Form.List name="decisions">
                  {(fields, { add, remove }) => {
                    return (
                      <div>
                        {fields.map(field => (
                          <Space
                            key={field.key}
                            style={{ display: "flex", marginBottom: 10 }}
                            align="start"
                            direction="horizontal"
                          >
                            <Card>
                              <Form.Item
                                {...field}
                                name={[field.name, "desiscionName"]}
                                fieldKey={[field.fieldKey, "desiscionName"]}
                                rules={[
                                  {
                                    required: true,
                                    message:
                                      "Choose a name for the design decision",
                                  },
                                ]}
                              >
                                <Input placeholder="Name: e.g. Plastic" />
                              </Form.Item>
                              <Form.Item
                                {...field}
                                name={[field.name, "desisciondDesc"]}
                                fieldKey={[field.fieldKey, "desisciondDesc"]}
                                rules={[
                                  {
                                    required: true,
                                    message:
                                      "Add a short description of the decision",
                                  },
                                ]}
                              >
                                <TextArea
                                  placeholder="A short description of the decision"
                                  autoSize={{ minRows: 2, maxRows: 6 }}
                                />
                              </Form.Item>

                              <MinusCircleOutlined
                                onClick={() => {
                                  remove(field.name)
                                }}
                              />
                            </Card>
                          </Space>
                        ))}
                        <Form.Item>
                          <Button
                            type="dashed"
                            onClick={() => {
                              add()
                            }}
                            block
                          >
                            <PlusOutlined /> Add design decision
                          </Button>
                        </Form.Item>
                      </div>
                    )
                  }}
                </Form.List>

                {/* ACTORS */}
                <Divider orientation="left">
                  Actors involved and impacts
                </Divider>
                <Form.List name="actors">
                  {(fields, { add, remove }) => {
                    return (
                      <div>
                        {fields.map(field => (
                          <Space
                            key={field.key}
                            style={{ display: "flex", marginBottom: 10 }}
                            align="start"
                            direction="vertical"
                          >
                            <Card>
                              <Form.Item
                                {...field}
                                name={[field.name, "actorName"]}
                                fieldKey={[field.fieldKey, "actorName"]}
                                rules={[
                                  {
                                    required: true,
                                    message: "Please name the actor",
                                  },
                                ]}
                              >
                                <Input placeholder="Actor name" />
                              </Form.Item>

                              <Form.Item
                                {...field}
                                label="Hazards"
                                name={[field.name, "actorHazard"]}
                                fieldKey={[field.fieldKey, "actorHazard"]}
                                rules={[
                                  {
                                    required: false,
                                    message: "What hazards can arise?",
                                  },
                                ]}
                              >
                                <TextArea
                                  placeholder="What hazards can arise?"
                                  autoSize={{ minRows: 2, maxRows: 6 }}
                                />
                              </Form.Item>

                              <Form.Item
                                {...field}
                                label="Issues"
                                name={[field.name, "actorIssues"]}
                                fieldKey={[field.fieldKey, "actorIssues"]}
                                rules={[
                                  {
                                    required: false,
                                    message: "What issues are emerging?",
                                  },
                                ]}
                              >
                                <TextArea
                                  placeholder="What issues are emerging?"
                                  autoSize={{ minRows: 2, maxRows: 6 }}
                                />
                              </Form.Item>

                              <Form.Item
                                {...field}
                                label="Positive"
                                name={[field.name, "actorPositive"]}
                                fieldKey={[field.fieldKey, "actorPositive"]}
                                rules={[
                                  {
                                    required: false,
                                    message: "Are there any positive effects?",
                                  },
                                ]}
                              >
                                <TextArea
                                  placeholder="Are there any positive effects?"
                                  autoSize={{ minRows: 2, maxRows: 6 }}
                                />
                              </Form.Item>

                              <MinusCircleOutlined
                                onClick={() => {
                                  remove(field.name)
                                }}
                              />
                            </Card>
                          </Space>
                        ))}
                        <Form.Item>
                          <Button
                            type="dashed"
                            onClick={() => {
                              add()
                            }}
                            block
                          >
                            <PlusOutlined /> Add actor & impact
                          </Button>
                        </Form.Item>
                      </div>
                    )
                  }}
                </Form.List>

                {/* Description */}
                <Divider orientation="left">Description & details</Divider>
                <Form.Item name="description">
                  <TextArea
                    placeholder="Here you can explain a little more about the scenario. You may also want to describe the context in which the actors are operating."
                    autoSize={{ minRows: 2, maxRows: 10 }}
                  />
                </Form.Item>

                <Form.Item
                  label="Your e-mail for further questions"
                  name="email"
                  rules={[
                    {
                      required: false,
                      type: "email",
                      message: "This is not a valid e-mail address",
                    },
                  ]}
                >
                  <Input placeholder="your@mail.com" />
                </Form.Item>

                <Form.Item {...tailLayout}>
                  <Button type="primary" htmlType="submit">
                    Submit
                  </Button>
                </Form.Item>
              </Form>
            </TabPane>
          </Tabs>
        </div>
      </div>
    </section>
  )
}
