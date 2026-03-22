
## 📖 项目简介
本项目是一款基于 PC 端开发的 **3D 交互式综合物理实验仿真软件**，旨在将初中物理中抽象、难以实操或存在危险的实验具象化。


**项目具备较高的教育商业落地价值，可作为数字化教具无缝接入初高中物理课堂。** 它通过“寓教于乐”的沉浸式体验，让学生在玩游戏的过程中轻松吸收硬核知识，大幅提升物理学习的认知深度与趣味性，赋能一线课堂，真正做到**“学生爱玩，老师好教”**。

玩家将以第一人称视角，在智能助手“阿古”的引导下穿梭于充满未来感的实验室大厅，通过跨越“传送门”进入不同的专业实验舱，亲手操作器材完成四大核心物理探究。
<table>
  <tr>
    <td align="center" width="33.33%">
      <img src="https://github.com/user-attachments/assets/5c625901-884e-4663-b37c-f93f4933bf98" alt="传送门" />
    </td>
    <td align="center" width="33.33%">
      <img src="https://github.com/user-attachments/assets/c3984317-0ead-4581-bdf4-6362aaa4f358" alt="封面" />
    </td>
    <td align="center" width="33.33%">
      <img src="https://github.com/user-attachments/assets/e83d97f3-83ff-477a-840a-b1012e70d118" alt="游戏画面" />
    </td>
  </tr>
</table>

## 🚀 核心技术与工程亮点

* **💧 核心突破：流体浮力高拟真物理模拟**
  * 完全摒弃了传统的预设动画方案。通过 C# 编写核心底层算法，**实时计算物体浸入水中的排开体积 ($V_{排}$)**。
  * 严格遵循 $F_{浮} = \rho \cdot g \cdot V_{排}$ 公式，在物理引擎的 FixedUpdate 周期内逐帧施加动态浮力。并引入流体阻尼（Drag）模型，完美还原木块入水的减速缓冲、悬浮波动，以及铁块沉底的真实操作反馈。
<img src="https://github.com/user-attachments/assets/4e54ae0e-727d-47de-bdf8-cf1233a0e78d" alt="gif2-1-ezgif com-video-to-gif-converter" width="500" />

* **⚙️ 多模块物理系统集成与 FSM 状态机**
  * 采用**有限状态机（FSM）**管理复杂的探究式实验心流，实现了“大厅接取任务 - 传送门无缝加载 - 四大实验舱交互验证”的严密逻辑闭环。精准调控多学科场景下的物理引擎参数，确保各个模块互不干扰。

* **💼 工程化与协同管理**
  * 熟练运用 **Git/GitHub** 进行代码版本控制与模块化分支管理；在开发周期内，运用成熟的**项目管理**思维进行需求拆解与排期，保障了复杂物理系统的稳健开发与高效迭代。

---



## 🧪 四大核心实验舱展示

项目精心打造了四个高度还原的物理实验场景，将枯燥的公式转化为生动的交互验证：

### 1. 阿基米德原理浮力验证（核心）
* **玩法与验证：** 玩家自由操控不同密度、不同体积的小球投入水槽。
* **技术呈现：** 玩家可直观观察到物体在水中的真实动态沉浮，深度理解密度、体积与浮力之间的物理关系。
<table>
  <tr>
    <td align="center" width="50%">
      <img src="https://github.com/user-attachments/assets/27529f12-67cd-48ce-9a53-04ecb7f3e9ec" alt="gif-1" />
    </td>
    <td align="center" width="50%">
      <img src="https://github.com/user-attachments/assets/c4f5a7f3-0d78-4a96-87f9-6bb3b8421f58" alt="实机画面" />
    </td>
  </tr>
</table>

### 2. 热学模拟（热气球）实验
* **玩法与验证：** 玩家亲自操控燃烧器，观察热空气膨胀带来的升力变化，体验热气球从地面逐渐升空的过程。
* **技术呈现：** 模拟热力学原理，动态计算气囊内空气受热膨胀后的密度变化，产生大于重力的向上合力，实现真实的热气球升降控制。
<img src="https://github.com/user-attachments/assets/4be2a66a-29d5-4407-823b-092b154fa187" alt="实机画面" width="500" />


### 3. 力学运动（自由落体）实验
* **玩法与验证：** 在抽真空的理想环境舱内，同时释放不同质量的小球。
* **技术呈现：** 精准还原无空气阻力环境下的重力加速度 ($g$) 表现，直观打破“重物落得快”的视觉错觉，验证经典力学定律。
<table>
  <tr>
    <td align="center" width="50%">
      <img src="https://github.com/user-attachments/assets/6887b090-0679-4b63-959b-191af31852a5" alt="自由落体实验" />
    </td>
    <td align="center" width="50%">
      <img src="https://github.com/user-attachments/assets/5fcc80e9-2936-44df-b3ab-33d3314fcf0d" alt="自由落体" />
    </td>
  </tr>
</table>

### 4. 小球摩擦力实验
* **玩法与验证：** 玩家可切换不同的斜面与水平面材质（如玻璃、木板、毛巾），操作小球滚下并测量其最终滑行距离。
* **技术呈现：** 通过调整物理引擎中不同材质表面的动态与静态摩擦系数（Friction），精准模拟阻力对物体运动状态（减速至停止）的量化影响。

---
<table>
  <tr>
    <td align="center" width="50%">
      <img src="https://github.com/user-attachments/assets/76d021ab-a582-4c34-bd35-2580303cc72c" alt="摩擦力实验 1" />
    </td>
    <td align="center" width="50%">
      <img src="https://github.com/user-attachments/assets/63715f6c-e1f8-48bf-b7aa-298de6e42a28" alt="小球摩擦力实验 2" />
    </td>
  </tr>
</table>

## 🛠 技术栈

**PC 端开发** | **Unity 3D** | **C# 底层物理算法** | **FSM (有限状态机)** | **Git (GitHub) 协同** | **敏捷项目管理**
